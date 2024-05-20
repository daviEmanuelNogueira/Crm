using Crm.Application.ViewModel;
using Crm.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Crm.WEB.Pages
{
    public class CreateModel : PageModel
    {
        private readonly HttpClient _client;

        public CreateModel(HttpClient client)
        {
            _client = client;
        }

        [BindProperty]
        public AtendimentoVM Atendimento { get; set; }

        [BindProperty]
        public int SelectedStatusId { get; set; }

        [BindProperty]
        public int SelectedSubstatusId { get; set; }

        public List<Status> StatusList { get; set; }
        public List<Substatus> SubstatusList { get; set; }
        public List<Motivo> MotivoList { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            StatusList = await _client.GetFromJsonAsync<List<Status>>("https://localhost:7030/api/status/getall");
            MotivoList = await _client.GetFromJsonAsync<List<Motivo>>("https://localhost:7030/api/motivo/getall");
            SubstatusList = new List<Substatus>(); // Inicialmente vazio

            return Page();
        }

        public async Task<JsonResult> OnGetSubstatusesAsync(int statusId)
        {
            SubstatusList = await _client.GetFromJsonAsync<List<Substatus>>($"https://localhost:7030/api/status/{statusId}/substatuses");
            return new JsonResult(SubstatusList);
        }
    }
}
