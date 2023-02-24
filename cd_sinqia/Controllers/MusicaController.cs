using cd_sinqia.Repository;
using Microsoft.AspNetCore.Mvc;

namespace cd_sinqia.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MusicaController : Controller
    {

        public MusicaRepository _repository { get; set; }

        //Controller chamando pegando o repository
        public MusicaController()
        {
            _repository = new MusicaRepository();
        }

        //Métodos da controller
        [HttpPost("inserir")]
        public ActionResult InserirMusica(Musica musica)
        {
            return Ok(_repository.InserirMusica(musica));
        }

        [HttpPut("editar")]
        public ActionResult EditarMusica(Musica musica, int id)
        {
            return Ok(_repository.EditarMusica(musica, id));
        }

        [HttpDelete("excluir")]
        public ActionResult ExcluirMusica(int id)
        {
            return Ok(_repository.ExcluirMusica(id));
        }

    }
}
