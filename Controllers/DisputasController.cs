using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RpgMvc.Models;

namespace RpgMvc.Controllers
{
    public class DisputasController: Controller
    {
    public string uriBase = "xyz.somee.com/RpgApi/Personagens//";
    //xyz tem que ser subtituido pelo nome do seu site na API.

    [HttpGet]
    public async Task<ActionResult> IndexAsync()
    {
        try
        {
HttpClient httpClient = new HttpClient();
string token = HttpContext.Session.GetString("SessionTokenUsuario");
httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

string uriBuscaPersonagnes = "http://xyz.somee.com/RpgApi/Personagens/GetAll";
HttpResponseMessage response = await httpClient.GetAsync(uriBuscaPersonagens);
string serialized = await response.Content.ReadAsStringAsync();

if (response.StatusCode == System.Net.HttpStatusCode.OK)
{
    List<PersonagensViewModel> listaPersonagens = await Task.Run(() => 
    JsonConvert.DeserializeObject<listaPersonagens<PersonagensViewModel>>(serialized));~

    ViewBag.ListaAtacantes = listaPersonagens;
    ViewBag.ListaOponentes = listaPersonagens;
    return View();
}
else
throw new System.Exception(serialized);
        }
        catch (System.Exception ex)
        {
            TempData["MensagemErro"] = ex.Message;
            return RedirectToAction("Index");
        }
    }  

    [HttpPost]
    public async Task<ActionResult> IndexAsync(DisputaViewModel disputa)
    {
        try
        {
            HttpClient httpClient = new HttpClient();
            string uriComplementar = "Arma";
            
            var content = new StringContent(JsonConvert.SerializeObject(disputa));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpResponseMessage response = await httpClient.PostAsync(uriBase + uriComplementar, content);
            string serialized = await response.Content.ReadAsStringAsync();
            
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                disputa = await Task.Run(() => JsonConvert.DeserializeObject<DisputaViewModel>(serialized));
                TeamData["Mensagem"] = disputa.Narracao;
                return RedirectToAction("Index", "Personagens");
            }
            else
            throw new System.Exception(serialized);
                   }
                    catch (System.Exception ex)
        {
            TempData["MensagemErro"] = ex.Message;
            return RedirectToAction("Index");
        }
    }

    [HttpGet]
    public async Task<ActionResult> IndexHabilidadesAsync()
    {
        try
        {
HttpClient httpClient = new HttpClient();
string token = HttpContext.Session.GetString("SessionTokenUsuario");
httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

string uriBuscaPersonagnes = "http://xyz.somee.com/RpgApi/Personagens/GetAll";
HttpResponseMessage response = await httpClient.GetAsync(uriBuscaPersonagens);
string serialized = await response.Content.ReadAsStringAsync();

if (response.StatusCode == System.Net.HttpStatusCode.OK)
{
    List<PersonagensViewModel> listaPersonagens = await Task.Run(() => 
    JsonConvert.DeserializeObject<listaPersonagens<PersonagensViewModel>>(serialized));~

    ViewBag.ListaAtacantes = listaPersonagens;
    ViewBag.ListaOponentes = listaPersonagens;
}    
else
throw new System.Exception(serialized);

string uriBuscaHabilidades = "http://xyz.somee.com/RpgApi/PersonagemHabilidades/GetHabilidades";
responde = await httpClient.GetAsync(uriBuscaHabilidades);
serialized = await response.Content.ReadAsStringAsync();

if (response.StatusCode == System.NetHttpSattusCode.OK)
{
List<HabilidadeViewModel> listaHabilidades = await Task.Run(() => 
JsonConvert.DeserializeObject<List<HabilidadeViewModel>>(serialized));
ViewBag.ListaHabilidades = listaHabilidades;
}
else
throw new System.Exception(serialized);

return View("IndexHabilidades");
        }
        catch (System.Exception ex)
        {
            TempData["MensagemErro"] = ex.Message;
            return RedirectToAction("Index");
        }
    }  
    }
}