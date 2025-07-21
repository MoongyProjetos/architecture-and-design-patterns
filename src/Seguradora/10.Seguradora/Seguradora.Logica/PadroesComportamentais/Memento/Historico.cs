namespace Seguradora.Logica.PadroesComportamentais.Memento;

/// <summary>
/// Classe que representa o histórico de mementos.
/// Armazena os mementos em uma pilha, permitindo desfazer ações.
/// Esta classe é parte do padrão Memento, que permite salvar e restaurar o estado de um objeto.
/// O histórico pode ser usado para desfazer ações, mantendo o estado anterior do objeto.
/// </summary>
public class Historico
{
    private readonly Stack<MementoProposta> _mementos = new();

    public void Salvar(MementoProposta memento) => _mementos.Push(memento);
    public MementoProposta Desfazer()
    {
        _ = _mementos.Pop();
        return _mementos.Peek();
    }
}
