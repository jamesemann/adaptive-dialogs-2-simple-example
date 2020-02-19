#### Background

This sample demonstrates the basic principles of loading an adaptive dialog from a `.dialog` file.

It delivers the following conversations demonstrating basic input capture and conditional using an if action:

***Bot: What's the secret?***

***User: 1234***

***Bot: you got it***

***Bot: What's the secret?***

***User: 5678***

***Bot: Sorry, that's not right***

Using the following `.dialog` conversation definition:

```
{
  "$schema": "../app.schema",
  "$kind": "Microsoft.AdaptiveDialog",
  "triggers": [
    {
      "$kind": "Microsoft.OnBeginDialog",
      "actions": [
        {
          "$kind": "Microsoft.TextInput",
          "prompt": "Whats the secret?",
          "property": "user.secret"
        },
        {
          "$kind": "Microsoft.IfCondition",
          "condition": "user.secret == '1234'",
          "actions": [
            {
              "$kind": "Microsoft.SendActivity",
              "activity": "You got it"
            }
          ]
        },
        {
          "$kind": "Microsoft.IfCondition",
          "condition": "user.secret != '1234'",
          "actions": [
            {
              "$kind": "Microsoft.SendActivity",
              "activity": "Sorry, that's not right"
            }
          ]
        }
      ]
    }
  ]
}
```

#### Running the code

After cloning the repo, either launch the app using Visual Studio or from dotnet cli using `dotnet run`.  Then connect to the bot using the included Bot Framework Emulator file `adaptive-dialogs-2-simple-example.bot`.

