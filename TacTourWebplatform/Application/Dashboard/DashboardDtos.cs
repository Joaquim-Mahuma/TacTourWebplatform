using TacTourWebplatform.Application.Reservas;

namespace TacTourWebplatform.Application.Dashboard;

public class DashboardMetricasResponse
{
    public int PacotesAtivos { get; set; }

    public int ReservasEmCurso { get; set; }

    public decimal ValorEmConfirmacao { get; set; }
}

public class DashboardResumoResponse
{
    public DashboardMetricasResponse Metricas { get; set; } = null!;

    public List<ReservaListagemResponse> ReservasRecentes { get; set; } = [];
}
