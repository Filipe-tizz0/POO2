Documentação para o DLL:

  O namespace usado é DLLComDocumentacaoGit;
  
  Para ter acesso ao método de cálculo crie um objeto da Classe 'Calculos_Areas';
  
  Com o objeto instanciando a classe, basta utilizar o método 'Area_Paralelepipedo' para calcular a área de um Cilindro:
    - Os parâmentros do método são o raio do tipo double e altura do tipo double;
    - O valor retornado será do tipo double; 

Exemplo:
  using DLLComDocumentacaoGit;

  Calculos_Areas c_a =  new Calculos_Areas();
  Console.WriteLine(c_a.Area_Paralelepipedo(2.3,12.8));

  - retorno: 
218,21502571834702
