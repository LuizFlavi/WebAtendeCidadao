using Microsoft.AspNetCore.Mvc;
using WebAtendeCidadao.Models;
using WebAtendeCidadao.Services;
using System.Threading.Tasks;

public class SolicitacaoController : Controller
{
    private readonly WebAtendeCidadaoServices _solicitacaoService;

    public SolicitacaoController(WebAtendeCidadaoServices solicitacaoService)
    {
        _solicitacaoService = solicitacaoService;
    }

    [HttpGet]
    public IActionResult Create()
    {        
        var solicitacaoModel = new SolicitacaoModel();
        return View(solicitacaoModel);
    }

    [HttpPost]
    public async Task<IActionResult> Create(SolicitacaoModel solicitacao)
    {
        if (ModelState.IsValid)        {
            
            var success = await _solicitacaoService.CreateSolicitacaoAsync(solicitacao);
            if (success)            {
                
                return RedirectToAction("Success");
            }
            else           {
                
                ModelState.AddModelError("", "Erro ao criar a solicitação.");
            }
        }        
        return View(solicitacao);
    }   
    
    [HttpGet]
    public async Task<IActionResult> Index()
    {
       
        var solicitacoes = await _solicitacaoService.GetSolicitacoesAsync();
        return View(solicitacoes);
    }

    
    [HttpGet]
    public IActionResult Success()
    {
        return View(); 
    }
}



