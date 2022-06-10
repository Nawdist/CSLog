# CSLog

Some utilites i made to practice C#. Use it if you want, i don't recommend to because optimization was *not* on mind

You can just grab the `Logger.cs` file and it'll do the trick.

Feel free to modify the code to fit your needs, 70% of it was written by Copilot anyways.

If, for god knows why, you chose you to use this, here's a brief overview

- [CSLog](#cslog)
- [Loading bar](#loading-bar)
    - [Update](#update)
    - [End](#end)
- [Logger](#logger)
    - [Methods](#methods)
- [Chalker](#chalker)
  - [Colors](#colors)
    - [Foreground colors](#foreground-colors)
    - [Background colors](#background-colors)
    - [Additional Styles](#additional-styles)

# Loading bar
```cs
    using CSLog;
    //...
    
        LoadingBar bar = new LoadingBar();
        bar.Start(); //Be sure to call the Start() method before using any other method
    //...
```

### Update

```cs
public string Update (int level);
```

Set the loading bar to the percentage specified.   
Examples:
```cs
bar.Update(10)
```

```shell
>>/ [█                       ] 10%
```
---
```cs
bar.Update(75)
```
```shell
>>| [██████████████████      ] 75%
```
---
Overload:
```cs
public string Update();
```
Simply updates the spinner without any changes to the loading bar.

### End
Overloads:
```cs
public void End(string message, LoadingState state);
``` 
```cs
public void End(string message);
``` 
```cs
public void End();
```
Terminates the loading bar with an optional message and state.

```cs
LoadingBar bar = new LoadingBar();

bar.End("Finished task successfully!", LoadingState.Success);
>> ✓ Finished task successfully!

bar.End("Task failed :/", LoadingState.Error);
>> ✗ Task Failed :/

bar.End("Outdated version", LoadingState.Warning);
>> ⚠ Outdated version

bar.End("Outdated version", LoadingState.Info);
>> ⓘ Installed Version 7.26
```

# Logger
Essential methods for logging.

### Methods
Each of their purpose is pretty self-explanatory

```cs
public void Info(string message)
```
```cs
public void Error(string message)
```
```cs
public void Success(string message)
```
```cs
public void Warning(string message)
```
```cs
public void Debug(string message)
```

# Chalker
String extension methods for colored output

## Colors
### Foreground colors
- Red
- Green
- Yellow
- Blue
- Cyan
- Magenta
- White
- Black

### Background colors
- BgRed
- BgGreen
- BgYellow
- BgBlue
- BgCyan
- BgMagenta
- BgWhite
- BgBlack

### Additional Styles
- Bold
- Italic
- Underline
- Strike
- Invert
- Hide
- Reset

---

Example:

```cs
string message = "some message";
Console.WriteLine(message.Bold().Italic().BgRed().Blue());
```