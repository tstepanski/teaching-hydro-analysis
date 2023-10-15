namespace TeachingHydroAnalysis;

public sealed class InputOutput : IInputOutput
{
    private readonly IService _service;
    private readonly TextReader _input;
    private readonly TextWriter _output;

    public InputOutput(IService service, TextReader input, TextWriter output)
    {
        _service = service;
        _input = input;
        _output = output;
    }

    public async Task RunAsync()
    {
        await WriteLineAsync("Welcome to Alice's Hydro Analysis System");
        await WriteLineAsync("Enter q/Q to quit!");
        await WriteLineAsync("Enter h/H for a list of commands");

        while (true)
        {
            var input = await _input.ReadLineAsync();

            if (string.IsNullOrWhiteSpace(input))
            {
                await WriteLineAsync("Please enter a command");

                continue;
            }

            var selection = input.ToLowerInvariant()[0];

            if (await ProcessSelectionAndGetIfShouldQuit(selection))
            {
                return;
            }
        }
    }

    private async Task<bool> ProcessSelectionAndGetIfShouldQuit(char selection)
    {
        switch (selection)
        {
            case 'h':
                await PrintHelpAsync();
                return false;
            case 'q':
                return true;
            case 's':
                await PrintSitesAsync();
                return false;
        }

        return false;
    }

    private async Task PrintSitesAsync()
    {
        await WriteLongLineAsync();
        await WriteLineAsync("Loading sites...");

        var sites = await _service.GetSitesAsync();

        await WriteLineAsync("Sites:");

        foreach (var site in sites)
        {
            await WriteLineAsync($"{site.Id}: {site.Name}");
        }

        await WriteLongLineAsync();
    }

    private async Task PrintHelpAsync()
    {
        await WriteLongLineAsync();
        await WriteLineAsync("Available commands are as follows:");
        await WriteLineAsync("h/H = help (this list)");
        await WriteLineAsync("q/Q = quit");
        await WriteLineAsync("s/S = sites");
        await WriteLongLineAsync();
    }

    private Task WriteLongLineAsync()
    {
        return WriteLineAsync("----------------------------------------");
    }

    private Task WriteLineAsync(string text)
    {
        return _output.WriteLineAsync(text);
    }
}