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
            var statusSubstatuses = await _client.GetFromJsonAsync<List<StatusSubstatus>>($"https://localhost:7030/api/statussubstatus/getbystatus/{statusId}");

            // Extrair os substatus e alimentar a SubstatusList
            SubstatusList = statusSubstatuses.Select(ss => new Substatus
            {
                Id = ss.Substatus.Id,
                Name = ss.Substatus.Name
            }).ToList();

            return new JsonResult(SubstatusList);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            int statusSubstatusId = await GetStatusSubstatusId(SelectedStatusId, SelectedSubstatusId);

            // Create the Atendimento object
            var atendimento = new Atendimento
            {
                Name = Atendimento.Name,
                Phone = Atendimento.Phone,
                Observations = Atendimento.Observations,
                StatusSubstatusId = statusSubstatusId,
                MotivoId = Atendimento.MotivoId
            };

            // Send the POST request to the API
            var response = await _client.PostAsJsonAsync("https://localhost:7030/api/atendimento", atendimento);



            return RedirectToPage();

        }

        private async Task<int> GetStatusSubstatusId(int statusId, int substatusId)
        {
            var response = await _client.GetAsync($"https://localhost:7030/api/statussubstatus/getstatussubstatusid/{statusId}/{substatusId}");

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Failed to retrieve StatusSubstatusId for StatusId: {statusId} and SubstatusId: {substatusId}");
            }

            var content = await response.Content.ReadAsStringAsync();
            return int.Parse(content);
        }
    }
}
