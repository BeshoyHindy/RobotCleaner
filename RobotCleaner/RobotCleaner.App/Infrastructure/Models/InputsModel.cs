using System.Collections.Generic;

namespace RobotCleaner.App.Infrastructure.Models
{
    public class InputsModel
    {
        public InputsModel()
        {
            Commands = new List<string>();
        }
        public string StartingPosition { get; set; }
        public IEnumerable<string> Commands { get; set; }

    }
}