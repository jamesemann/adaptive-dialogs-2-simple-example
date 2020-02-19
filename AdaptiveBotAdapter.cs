using System;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs.Adaptive;
using Microsoft.Bot.Builder.Dialogs.Debugging;
using Microsoft.Bot.Builder.Dialogs.Declarative;
using Microsoft.Bot.Builder.Dialogs.Declarative.Resources;
using Microsoft.Bot.Builder.Integration.AspNet.Core;
using Microsoft.Bot.Builder.LanguageGeneration;
using Microsoft.Bot.Connector.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace adaptive_dialogs_2_simple_example
{
    public class AdaptiveBotAdapter : BotFrameworkHttpAdapter
    {
        public AdaptiveBotAdapter(ICredentialProvider credentialProvider, IConfiguration configuration, ILogger<BotFrameworkHttpAdapter> logger, IStorage storage, UserState userState, ConversationState conversationState, ResourceExplorer resourceExplorer)
            : base(credentialProvider)
        {
            this.Use(new RegisterClassMiddleware<IConfiguration>(configuration));
            this.UseStorage(storage);
            this.UseState(userState, conversationState);
            this.UseResourceExplorer(resourceExplorer);
            this.UseLanguageGeneration(resourceExplorer);
            this.UseAdaptiveDialogs();
            
            this.OnTurnError = async (turnContext, exception) =>
            {
                if (conversationState != null)
                {
                    // clear the conversationState to ensure that the next request for user will be routed to a new conversation
                    await conversationState.DeleteAsync(turnContext);
                }
            };
        }
    }
}
