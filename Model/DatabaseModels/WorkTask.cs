namespace WebApp.Model.DatabaseModels
{
    public class WorkTask
    {
		[System.ComponentModel.DataAnnotations.Key]
		public int Id { get; set; }
		public string Description { get; set; } = String.Empty;
	}
}
