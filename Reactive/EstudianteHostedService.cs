using Microsoft.AspNetCore.SignalR;
using PRUEBA_PRACTICA_DE_CONOCIMIENTOS_EN_FRAMEWORKS.Data;

namespace PRUEBA_PRACTICA_DE_CONOCIMIENTOS_EN_FRAMEWORKS.Reactive
{

    public class EstudianteHostedService : IHostedService, IDisposable
    {
        private readonly IHubContext<EstudianteHub> _estudianteHub;
    
        private Timer _timer;

        private EstudianteHostedService(IHubContext<EstudianteHub> estudianteHub)
        {
            _estudianteHub = estudianteHub;
        }

        private readonly ApplicationDbContext _context;
        public EstudianteHostedService(ApplicationDbContext context)
        {
            _context = context;
        }  

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(SendInfo, null, TimeSpan.Zero,
            TimeSpan.FromSeconds(5));

            return Task.CompletedTask;
        }

       
        private void SendInfo(object? state)
        {
            IEnumerable<Estudiante> estudiante;
            estudiante = _context.Estudiantes.ToList();     
           
           _estudianteHub.Clients.All.SendAsync("Receive", estudiante);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask; 
        }

         public void Dispose()
        {
            _timer?.Dispose();
        }

    }




}
