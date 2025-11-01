using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces.Repositories;
using MediatR;

namespace Application.Commands.ExcluirPosicaoJogador
{
    public class ExcluirPosicaoJogadorCommandHandler
        : IRequestHandler<ExcluirPosicaoJogadorCommand, Unit>
    {
        private readonly IPosicaoJogadorRepository _posicaoJogadorRepository;

        public ExcluirPosicaoJogadorCommandHandler(
            IPosicaoJogadorRepository posicaoJogadorRepository
        )
        {
            _posicaoJogadorRepository = posicaoJogadorRepository;
        }

        public async Task<Unit> Handle(
            ExcluirPosicaoJogadorCommand request,
            CancellationToken cancellationToken
        )
        {
            foreach (var id in request.Ids)
            {
                await _posicaoJogadorRepository.ExcluirPosicaoJogadorAsync(id);
            }

            return Unit.Value;
        }
    }
}
