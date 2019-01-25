# 2º Projeto de Linguagens de Programação II

###### Projeto realizado por:
Joana Marques a21701929 <p>
Pedro Santos a21702907

##### Link do repositório GitHub : https://github.com/pedrosantosobral/DJD2Game

### Relatório:
Pedro: <p>
- Na class `Interactible` fez o método TriggerDialogueCondition(); <p>
- Na classe `Player` fez o método CheckForContinueDialogueClick() e fez pequenas alterações ao código disponibilizado pelo professor; <p>
- Criou a classe `DialogueManager` e fez os métodos StartDialogue() e EndDialogue(). <p>


Joana: <p>
- Na classe `Interactible`, fez os métodos TriggerDialogue() e GoNextSentense() ; <p>
- Fez a classe `MainMenu`; <p>
- Fez a classe `Dialogue`; <p>
- Na classe `DialogueManager` fez os métodos DisplayNextSentense() e TypeSentence().<p> 

O resto do código não mencionado foi reutilizado e adaptado das aulas de Desenvolvimentos de Jogos Digitais II.

Nota: Os nossos commits no git. não refletem o que foi feito por cada um, pois tivemos alguns problemas e acabámos por ter de colocar tudo junto depois.

O relatório foi feito por todos os elementos do grupo.

### Solução:
##### Arquitetura:
Separámos o código em várias classes.
Cada classe desepenha uma determinada função no código. <p>
O `CanvasManager` trata da interface do jogo: ativação e desativação de vários paineis. <p>
A classe `Dialogue` é um tipo de dados a ser usado pelo DialogueManager que armazena o texto e o nome da font. <p>
A classe `DialogueManager` classe que gere od diálogos de cada interactible. <p>
A classe `Interactible` tem toda a informação dos objetos com que se pode interagir. <p>
A classe `MainMenu` é a classe que gere os botões do menu inicial. <p>
A classe `Player` classe que faz ações sobre o objeto interactible observado no momento e faz a atualização do inventário. <p>

Coleções utilizadas: Queue() para a ordem dos diálogos e List() para armazenar os interactibles do inventário. <p>
Design patterns utilizados: Iterator para as corrotinas das frases dos diálogos. <p>

Um dos algoritmos que usámos foi para imprimir caracter a caracter dos diálogos.
```cs
IEnumerator TypeSentense(string sentense)
{
dialogueText.text = "";
//Go through all the chars in the sentense
foreach(char character in sentense.ToCharArray())
{
//add char
dialogueText.text += character;
yield return null;
}
}
```

##### Diagrama UML:
![UML](UML.png)

### Referências
* Código de referência das aulas de Desenvolvimento de Jogos Digitais II;
* [Brackeys](https://www.youtube.com/channel/UCYbK_tjZ2OrIZFBvU6CCMiA)

