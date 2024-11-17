using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterCommand
{
    public interface ICommandHanddle
    {
        public void ProcessCommand(Command command);
    }
}

