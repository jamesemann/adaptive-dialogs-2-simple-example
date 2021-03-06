﻿using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Dialogs.Adaptive;
using Microsoft.Bot.Builder.Dialogs.Debugging;
using Microsoft.Bot.Builder.Dialogs.Declarative;
using Microsoft.Bot.Builder.Dialogs.Declarative.Resources;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace adaptive_dialogs_2_simple_example
{
    public class AdaptiveBot : ActivityHandler
    {
        private ResourceExplorer resourceExplorer;
        private DialogManager dialogManager;

        public AdaptiveBot(ResourceExplorer resourceExplorer)
        {
            this.resourceExplorer = resourceExplorer;
            var resource = this.resourceExplorer.GetResource("main.dialog");
            this.dialogManager = new DialogManager(DeclarativeTypeLoader.Load<AdaptiveDialog>(resource, resourceExplorer, DebugSupport.SourceMap));
        }

        public async override Task OnTurnAsync(ITurnContext turnContext, CancellationToken cancellationToken = default(CancellationToken))
        {
            await dialogManager.OnTurnAsync(turnContext, cancellationToken);
        }
    }
}
