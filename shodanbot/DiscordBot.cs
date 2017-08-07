using Discord;
using Discord.Commands;
using System;

namespace shodanbot
{
    public class DiscordBot
    {
        DiscordClient client;
        CommandService commands;

        public DiscordBot()
        {

            client = new DiscordClient(input =>
            {
                input.LogLevel = LogSeverity.Info;
                input.LogHandler = Log;
            });


            client.UsingCommands(input =>
            {   //Commands will only work if ! is at the start of command.
                input.PrefixChar = '!'; 
                input.AllowMentionPrefix = true;
            });

            commands = client.GetService<CommandService>(); //gets commands

            //Commands

            //Words
            commands.CreateCommand("420").Do(async (e) =>
            {
                await e.Channel.SendMessage("Blaze it");
            });

            //Image links
            commands.CreateCommand("pickle").Do(async (e) =>
            {
                await e.Channel.SendMessage("I'M PICKLE RICK, https://i.imgur.com/3VhMoBD.png");
            });

            //song playlist

            //if correct command //then
            //{
               //removed, will readd functionality later. 
            //}
            //else 
            commands.CreateCommand("playsong").Do(async (e) =>
            {
                await e.Channel.SendMessage("I dunno how, heres a youtube video. https://www.youtube.com/watch?v=k33-4f14eZQ");
            }); //Broken, will fix later
            //end of commands

            //connects file to discord bot
            client.ExecuteAndWait(async () =>
            {
                await client.Connect("MzQzOTM2NDE2NDU3MjkzODM0.DGllFA.buMDpMhnwPoEgBqEYlnBv3e8eqo", TokenType.Bot);
            });

        }

        private void Log(object sender, LogMessageEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
