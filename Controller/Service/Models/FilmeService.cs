﻿using AutoMapper;
using Domain.Models;
using Repository.Models;
using System;
using System.Linq;

namespace Service.Models
{
    public class FilmeService
    {
        private readonly FilmeRepository _filmeRepository;
        private readonly IMapper _mapper;

        public FilmeService(FilmeRepository filmeRepository, IMapper mapper)
        {
            _filmeRepository = filmeRepository;
            _mapper = mapper;
        }

        public object BuscarTodos()
        {
            return _filmeRepository.GetAll().ToList();
        }

        public object Salvar(Filme filme)
        {
            _filmeRepository.Save(filme);

            return filme;
        }

        public object Atualizar(Filme filme, int id)
        {
            _filmeRepository.VerificarExistencia("Filme não encontrado!", id);

            filme.Id = id;

            _filmeRepository.Update(filme);

            return filme;
        }

        public void Deletar(int id)
        {
            _filmeRepository.VerificarExistencia("Filme não encontrado!", id);

            // verificar locacoes

            _filmeRepository.Delete(x => x.Id == id);
        }
    }
}