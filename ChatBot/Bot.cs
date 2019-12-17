
using Microsoft.Azure.CognitiveServices.Knowledge.QnAMaker;
using Microsoft.Azure.CognitiveServices.Knowledge.QnAMaker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBot
{
    class Bot
    {

        private QnAMakerRuntimeClient cliente;

        public Bot()
        {
            string EndPoint = Properties.Settings.Default.EndPoint;
            string Key = Properties.Settings.Default.Key;
            string Id = Properties.Settings.Default.Id; 
            cliente = new QnAMakerRuntimeClient(new EndpointKeyServiceClientCredentials(Key)) { RuntimeEndpoint = EndPoint };
        }

        public async Task<string> RespuestaBotAsync(string texto)
        {
            string Id = Properties.Settings.Default.Id;
            string pregunta = texto;
            QnASearchResultList response = await cliente.Runtime.GenerateAnswerAsync(Id, new QueryDTO { Question = pregunta });
            return response.Answers[0].Answer;
        }
    }
}
