using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.GameLogic
{
    class GameLogic
    {
        public Game game { get; set; }

        public GameLogic(Game game)
        {
            this.game = game;
        }

        public void GameProcess()
        {
            while (true)
            {
                foreach(Bot bot in game.Gamers)
                {
                    if (bot.Attack != false)
                    {
                        game.Gamers.First().botLogic.Attack(game.Round, bot.Hand, game.Deck.Trump);

                    }
                    if (bot.Attack != true)
                    {
                        game.Gamers.First().botLogic.Defence(game.Round, bot.Hand, game.Deck.Trump);

                    }
                }

            }
        }
    }
}
