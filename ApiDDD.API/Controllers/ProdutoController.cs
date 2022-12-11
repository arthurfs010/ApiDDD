using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ApiDDD.Application;
using ApiDDD.Application.DTO;
using ApiDDD.Application.Interface;
using ApiDDD.Domain.Entities;
using ApiDDD.Infraestructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace ApiDDD.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProdutoController : ODataController
    {
        private readonly IApplicationServiceProduto _applicationServiceProduto;

        public ProdutoController(IApplicationServiceProduto applicationServiceProduto)
        {
            _applicationServiceProduto = applicationServiceProduto;
        }

        [HttpGet("codigo={codigo:int}")]
        public ActionResult<string> GetByCodigo(int codigo)
        {
            return Ok(_applicationServiceProduto.GetByCodigo(codigo));
        }

        [HttpGet("iteminicio={inicio:int}/maxitens={itens:int}")]
        [EnableQuery]
        public IEnumerable<ProdutoDTO> GetAllComPagEQuery(int inicio = 0, int itens = 25)
        {
            itens = itens < 1 ? 25 : itens;

            var prods = _applicationServiceProduto.GetAll(inicio, itens);

            return prods;
        }

        [HttpGet]
        [EnableQuery]
        public IEnumerable<ProdutoDTO> GetAllComQuery(int inicio = 0, int itens = 1000)
        {
            var prods = _applicationServiceProduto.GetAll(inicio, itens);

            return prods;
        }

        [HttpPost]
        public ActionResult Post([FromBody] ProdutoDTO produtoDTO)
        {
            try
            {
                if (produtoDTO == null)
                    return NotFound();

                _applicationServiceProduto.Add(produtoDTO);
                return Ok("Produto salvo com sucesso!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut]
        public ActionResult Put([FromBody] ProdutoDTO produtoDTO)
        {
            try
            {
                if (produtoDTO == null)
                    return NotFound();
                
                _applicationServiceProduto.Update(produtoDTO);
                return Ok("Produto atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete()]
        public ActionResult Delete([FromBody] ProdutoDTO produtoDTO)
        {
            try
            {
                if (produtoDTO == null)
                    return NotFound();

                _applicationServiceProduto.Remove(produtoDTO);
                return Ok("Produto inativado com sucesso!");
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}

