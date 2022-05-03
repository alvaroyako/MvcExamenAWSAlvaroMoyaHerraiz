using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.Extensions.Configuration;
using MvcExamenAWSAlvaroMoyaHerraiz.Data;
using MvcExamenAWSAlvaroMoyaHerraiz.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MvcExamenAWSAlvaroMoyaHerraiz.Repositories
{
    public class RepositoryChampions
    {
        private string bucketName;
        private IAmazonS3 awsClient;
        private ChampionContext context;
        public RepositoryChampions(IAmazonS3 client, IConfiguration configuration,ChampionContext context)
        {
            this.awsClient = client;
            this.context = context;
            this.bucketName=configuration.GetValue<string>("AWS:AWSBucket");
        }

        public List<Equipo> GetEquipos()
        {
            return this.context.Equipos.ToList();
        }
        public List<Jugador> GetJugadores(int idequipo)
        {
            var consulta = from datos in this.context.Jugadores
                           where datos.IdEquipo == idequipo
                           select datos;
            return consulta.ToList();
        }

        public List<Apuesta> GetApuestas()
        {
            return this.context.Apuestas.ToList();
        }

        public Equipo FindEquipo(int idequipo)
        {
            return this.context.Equipos.SingleOrDefault(x => x.IdEquipo == idequipo);
        }

        public Jugador FindJugador(int idjugador)
        {
            return this.context.Jugadores.SingleOrDefault(x => x.IdJugador == idjugador);
        }

        public Apuesta FindApuesta(int idapuesta)
        {
            return this.context.Apuestas.SingleOrDefault(x => x.IdApuesta == idapuesta);
        }

        public void CrearJugador(Jugador jugador)
        {
            this.context.Jugadores.Add(jugador);
            this.context.SaveChanges();
        }

        public void CrearApuesta(Apuesta apuesta)
        {
            this.context.Apuestas.Add(apuesta);
            this.context.SaveChanges();
        }

        public int GetMaxIdApuesta()
        {
            if (this.context.Apuestas.Count() == 0)
            {
                return 1;
            }
            else
            {
                return this.context.Apuestas.Max(z => z.IdApuesta) + 1;
            }
        }

        public async Task <bool> UploadFile(Stream stream,string fileName)
        {
            PutObjectRequest request = new PutObjectRequest
            {
                InputStream = stream,
                Key = fileName,
                BucketName = this.bucketName
            };
            
            PutObjectResponse response =
    await this.awsClient.PutObjectAsync(request);
            if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

    }
}
