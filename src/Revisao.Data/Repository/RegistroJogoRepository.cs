using AutoMapper;
using Revisao.Data.Providers.MongoDb.Collections;
using Revisao.Data.Providers.MongoDb.Interfaces;
using Revisao.Domain.Entities;
using Revisao.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revisao.Data.Repository
{
    public class RegistroJogoRepository : IRegistroJogoRepository
    {
        private readonly IMongoRepository<RegistroJogoCollection> _jogoRepository;

        private readonly IMapper _mapper;

        #region - Construtores
        public RegistroJogoRepository(IMongoRepository<RegistroJogoCollection> cartaRepository, IMapper mapper)
        {
            _jogoRepository = cartaRepository;
            _mapper = mapper;
        }
        #endregion

        #region Funções do Arquivo      

        public async Task<IEnumerable<RegistroJogo>> ObterTodosOsJogos()
        {
            var cartaList = _jogoRepository.FilterBy(filter => true);

            List<RegistroJogo> lista = new List<RegistroJogo>();
            foreach (var item in cartaList)
            {
                lista.Add(new RegistroJogo(item.primeiroNumero, item.segundoNumero, item.terceiroNumero, item.quartoNumero, item.quintoNumero, item.sextoNumero ));
            }

            //return _mapper.Map<IEnurable<Produto>>(produtoList);

            return lista;
        }


        public async Task RegistrarJogo(RegistroJogo jogo)
        {
            //await _produtoRepository.InsertOneAsync(_mapper.Map<ProdutoCollection>(produto)));

            RegistroJogoCollection registroJogoCollection = new RegistroJogoCollection();
            registroJogoCollection.primeiroNumero = jogo.primeiroNumero;
            registroJogoCollection.segundoNumero = jogo.segundoNumero;
            registroJogoCollection.terceiroNumero = jogo.terceiroNumero;
            registroJogoCollection.quartoNumero = jogo.quartoNumero;
            registroJogoCollection.quintoNumero = jogo.quintoNumero;
            registroJogoCollection.sextoNumero = jogo.sextoNumero;

            await _jogoRepository.InsertOneAsync(registroJogoCollection);
        }
        #endregion
    }
}
