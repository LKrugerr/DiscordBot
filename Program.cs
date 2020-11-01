using Discord;
using Discord.WebSocket;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DiscordBot
{
    class Program
    {
        private readonly DiscordSocketClient _client;
        private readonly Random _random = new Random();


        

            static void Main(string[] args)
        {
            new Program().MainAsync().GetAwaiter().GetResult();
        }

        public Program()
        {
          
            _client = new DiscordSocketClient();

            _client.Log += LogAsync;
            _client.Ready += ReadyAsync;
            _client.MessageReceived += MessageReceivedAsync;
        }

        public async Task MainAsync()
        {
            await _client.LoginAsync(TokenType.Bot, ""); //token de segurança do bot
            await _client.StartAsync();

            await Task.Delay(Timeout.Infinite);
        }

        private Task LogAsync(LogMessage log)
        {
            Console.WriteLine(log.ToString());
            return Task.CompletedTask;
        }


        private Task ReadyAsync()
        {
            Console.WriteLine($"{_client.CurrentUser} is connected!");

            return Task.CompletedTask;
        }
        public int RandomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }

        private async Task MessageReceivedAsync(SocketMessage message)
        {

            if (message.Author.Id == _client.CurrentUser.Id)
            {
                return;
            }

            string[] fatosCuriosos = new string[7];
            fatosCuriosos[0] = "Ossos encontrados nas Ilhas Seymour nos mostram que, há quase 40 milhões de anos, pinguins mediam mais de 1,80 m de altura e pesavam quase 115 kg";
            fatosCuriosos[1] = "Tsundoku é o ato de comprar livros, mas não lê-los";
            fatosCuriosos[2] = "Corvos podem aprender a falar melhor do que papagaios";
            fatosCuriosos[3] = "Na Suécia, doadores de sangue recebem uma SMS de agradecimento quando o sangue doado foi utilizado por alguém";
            fatosCuriosos[4] = "No Japão, se um lutador de sumô fizer seu bebê chorar, é um sinal de boa sorte";
            fatosCuriosos[5] = "Marie Curie continua sendo a única pessoa a ganhar o Prêmio Nobel em duas ciências diferentes";
            fatosCuriosos[6] = "As pupilas das cabras são retangulares";


            if (message.Content == "/Fatos" )
                {
                    await message.Channel.SendMessageAsync(fatosCuriosos[(RandomNumber(0,6))]);
                }
          
        }



    }
}
