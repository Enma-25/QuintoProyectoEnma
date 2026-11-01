using QuintoProyecto.Models;
using QuintoProyecto.Services;
using Spectre.Console;

// bool running = true;

var MedicamentoService = new MedicamentoService();

string[] options = [
  "1. Agregar nuevo Medicamento",
  "2. Eliminar un Medicamento",
  "3. Mostrar todos los Medicamentos",
  "4. Salir"
];


while (true) {
  var selections = new SelectionPrompt<string>()
    .Title("Indica la opción a seleccionar: ")
    .HighlightStyle(Color.GreenYellow)
    .AddChoices(options)
    .WrapAround();

  var option = AnsiConsole.Prompt(selections);

  List<Medicamentos> medicamentos = MedicamentoService.FindAll();

  switch (option) {
    case "1. Agregar nuevo Medicamento":

      AnsiConsole.Clear();
      var nombre = AnsiConsole.Ask<string>("[DarkGoldenrod]Ingrese el nombre del medicamento: [/] ");
      var descripcion = AnsiConsole.Ask<string>("[DarkGoldenrod]Ingrese la descripción del medicamento: [/] ");

      var Ids = medicamentos.Max(m => m.Id);

      var newMedicamento = new Medicamentos {
        Id = Ids + 1,
        Nombre = nombre,
        Descripción = descripcion
      };

      MedicamentoService.Create(newMedicamento);
      AnsiConsole.Clear();
      AnsiConsole.MarkupLine("\n[green]Medicamento agregado correctamente.[/]\n");
      break;

    case "2. Eliminar un Medicamento":
      AnsiConsole.Clear();
      var id = AnsiConsole.Ask<int>("Indica el id del medicamento a eliminar:");
      AnsiConsole.WriteLine("");

      var confirm = AnsiConsole.Confirm("¿Estás seguro que deseas eliminarlo?:");

      if (confirm) {
        var deleted = MedicamentoService.Delete(id);

        if (deleted) {
          AnsiConsole.MarkupLine("\n[green]!Medicamento eliminado![/]\n");
          break;
        }

        AnsiConsole.MarkupLine("\n[red]¡Medicamento no encontrado![/]\n");
        break;
      }

      AnsiConsole.MarkupLine("\n[red]Operación cancelada[/]\n");

      break;
    case "3. Mostrar todos los Medicamentos":
      AnsiConsole.Clear();

      var table = new Table()
        .Title("Lista de mis medicamentos")
        .BorderColor(Color.Yellow)
        .RoundedBorder(); // .ShowRowSeparators()

      table.AddColumn("Id");
      table.AddColumn("Nombre");
      table.AddColumn("Descripción");
    

      foreach (var medicamento in medicamentos) {
        table.AddRow(medicamento.Id.ToString(), medicamento.Nombre, medicamento.Descripción);
      }

      AnsiConsole.Write(table);
      break;
    case "4. Salir":
      AnsiConsole.Clear();
      AnsiConsole.MarkupLine("[green]Fin de la aplicación.[/]");
      // running = false;
      // break;
      return;
  }
}
