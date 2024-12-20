# FluentResultNet :rocket:

**FluentResultNet** é uma biblioteca .NET que facilita o gerenciamento de retornos padronizados para métodos em aplicações. Este pacote oferece uma abordagem unificada para lidar com sucessos, falhas, mensagens de erro e exceções, reduzindo a complexidade no tratamento de respostas em métodos síncronos e assíncronos.

## Funcionalidades

- **Retornos Padronizados**: Garante consistência nos retornos de métodos em toda a aplicação.
- **Mensagens Detalhadas**: Suporte para mensagens personalizadas em operações de sucesso ou falha.
- **Manipulação de Exceções**: Captura e encapsula exceções para manter o controle de erros no fluxo da aplicação.
- **Suporte a Operações Assíncronas**: Métodos `SuccessAsync` e `FailureAsync` para facilitar o uso em cenários assíncronos.
- **Códigos de Resposta**: Retorna códigos de status HTTP (`200`, `400`, `500`, etc.) para facilitar a integração com APIs.

## Exemplo de Uso

### Serviço
```csharp
public async Task<Result<List<FuncionarioDto>>> List()
{
    try
    {
        var funcionarios = await _funcionarioRepository.List();

        var funcionarioDtos = _mapper.Map<List<FuncionarioDto>>(funcionarios);

        if (funcionarioDtos is null)
            return Result<List<FuncionarioDto>>.Failure("Nenhum funcionário encontrado");

        return await Result<List<FuncionarioDto>>.SuccessAsync(funcionarioDtos);
    }
    catch (Exception ex)
    {
        return await Result<List<FuncionarioDto>>.FailureAsync(500, "Falha no serviço.");
    }
}
```
### Controller

```csharp
[HttpGet]
[Route("all")]
public async Task<IActionResult> Get()
{
    var result = await _funcionarioService.List();
    return result.Succeeded ? Ok(result) : BadRequest(result);
}
```
### ⚙️ Instalação:

```html
Install-Package FluentResultNet
```

🤝 Contribuição

Contribuições são bem-vindas!

* Faça um fork do repositório.
* Crie uma branch para sua feature (git checkout -b feature/NovaFeature).
* Commit suas mudanças (git commit -m "Adicionei uma nova feature X").
* Faça um push para a branch (git push origin feature/NovaFeature).
* Abra um Pull Request.

⭐ Dê uma estrela!

Se você achou este pacote útil, não se esqueça de dar uma ⭐ no GitHub!
