using System.Collections.Generic;
using System.Windows;
using OsEngine.Entity;
using OsEngine.Language;
using OsEngine.Market;
using OsEngine.OsTrader.Panels;
using OsEngine.OsTrader.Panels.Attributes;
using OsEngine.OsTrader.Panels.Tab;

namespace OsEngine.Robots.BotsFromStartLessons
{
    [Bot("Lesson1HelloWorld")]
    public class Lesson1HelloWorld : BotPanel
    {
        public Lesson1HelloWorld(string name, StartProgram startProgram) : base(name, startProgram)
        {
            StrategyParameterButton button = CreateParameterButton("Hello World");

            button.UserClickOnButtonEvent += Button_UserClickOnButtonEvent;
        }

        private void Button_UserClickOnButtonEvent()
        {
            SendNewLogMessage("Hello World",Logging.LogMessageType.Error);
        }

        public override string GetNameStrategyType()
        {
            return "Lesson1HelloWorld";
        }

        public override void ShowIndividualSettingsDialog()
        {
            
        }
    }
}
