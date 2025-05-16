using System;
using SenaiKeys.Usuarios;

UsuarioManager manager = new UsuarioManager();

// Cadastro do primeiro Adm fixo
Adm adm = new Adm("dannys",1234, "Adm", "asdf");
manager.AdicionarUsuario(adm);

bool continuar = true;

while (continuar) {
    // Login
    Console.WriteLine("\n=== Login ===");
    Console.Write("Matrícula: ");
    int matriculaLogin = int.Parse(Console.ReadLine()!);
    Console.Write("Senha: ");
    string senhaLogin = Console.ReadLine()!;

    Usuario usuarioLogado = manager.ListarUsuarios()
        .FirstOrDefault(u => u.Matricula == matriculaLogin && u.Senha == senhaLogin)!;

    if (usuarioLogado == null) {
        Console.WriteLine("Matrícula ou senha inválidos.");
        continue;
    }

    Console.WriteLine($"\nBem-vindo, {usuarioLogado.Nome} ({usuarioLogado.Cargo})!");

    bool menuUsuario = true;
    while (menuUsuario) {
        int op = 1;
        Console.WriteLine("\nO que deseja fazer?");
        if (usuarioLogado.PodeCadastrarEditor())
            Console.WriteLine($"{op++} - Cadastrar Editor");
        if (usuarioLogado.PodeCadastrarDocente())
            Console.WriteLine($"{op++} - Cadastrar Docente");
        if (usuarioLogado.PodeRemoverDocente())
            Console.WriteLine($"{op++} - Remover Docente");
        Console.WriteLine($"{op++} - Listar Usuários");
        Console.WriteLine($"{op++} - Trocar de usuário");
        Console.WriteLine("0 - Sair");
        Console.Write("Opção: ");
        string opcao = Console.ReadLine()!;

        int menuIndex = 1;

        // Cadastro de Editor (apenas Adm)
        if (usuarioLogado.PodeCadastrarEditor() && opcao == $"{menuIndex++}") {
            Console.WriteLine("\n=== Cadastro de Editor ===");
            Console.Write("Nome: ");
            string nomeEditor = Console.ReadLine()!;
            Console.Write("Matrícula: ");
            int matriculaEditor = int.Parse(Console.ReadLine()!);
            Console.Write("Senha: ");
            string senhaEditor = Console.ReadLine()!;
            // Só Adm pode cadastrar editor
            if (usuarioLogado is Adm admLogado)
                admLogado.CadastrarEditor(nomeEditor, matriculaEditor, senhaEditor, manager);
            else
                Console.WriteLine("Você não tem permissão para cadastrar editor.");
        }
        // Cadastro de Docente (Adm ou Editor)
        else if (usuarioLogado.PodeCadastrarDocente() && opcao == $"{menuIndex++}") {
            Console.WriteLine("\n=== Cadastro de Docente ===");
            Console.Write("Nome: ");
            string nomeDocente = Console.ReadLine()!;
            Console.Write("Matrícula: ");
            int matriculaDocente = int.Parse(Console.ReadLine()!);
            Console.Write("Senha: ");
            string senhaDocente = Console.ReadLine()!;
            usuarioLogado.CadastrarDocente(nomeDocente, matriculaDocente, senhaDocente, manager);
        }
        // Remover Docente (Adm ou Editor)
        else if (usuarioLogado.PodeRemoverDocente() && opcao == $"{menuIndex++}") {
            Console.WriteLine("\n=== Remover Docente ===");
            Console.Write("Informe a matrícula do docente a remover: ");
            int matriculaDocenteRemover = int.Parse(Console.ReadLine()!);
            usuarioLogado.RemoverDocente(matriculaDocenteRemover, manager);
        }
        // Listar usuários
        else if (opcao == $"{menuIndex++}") {
            Console.WriteLine("\n=== Lista de Usuários ===");
            foreach (var usuario in manager.ListarUsuarios()) {
                Console.WriteLine($"{usuario.Cargo}: {usuario.Nome} (Matrícula: {usuario.Matricula})");
            }
        }
        // Trocar de usuário
        else if (opcao == $"{menuIndex++}") {
            menuUsuario = false;
        }
        // Sair
        else if (opcao == "0") {
            continuar = false;
            break;
        }
        else {
            Console.WriteLine("Opção inválida!");
        }
    }
}

Console.WriteLine("Programa finalizado.");
