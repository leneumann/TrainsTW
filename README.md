# TrainsThoughtWorks
## Resolução dos Problemas
Para resolução do item 1 ao 5, criei um algoritmo de busca próprio, não houve necessidade de algo mais complexo.  

Para resolução dos itens 6, 7 e 10, testei alguns algoritmos de de detecção de ciclos e também alguns de componentes fortemente conectados,
mas não atendiam a necessidade, então após analisar bem, imaginei o grafo proposto como uma árvore n-ária infinita, com isso pude aplicar 
uma busca em largura, usando um limitador de niveis de aprofundamento.  
Optei por criar uma classe para item proposto, para não criar complexidade ciclomática e facilitar a leitura do código, entretanto
ambas as classes tem um mesmo contrato.  

Para resolução dos itens 8 e 9 apliquei o algoritmo de Djikstra com algumas pequenas customizações para tratar o cenário onde a rota
de saída e chegada são os mesmos.  


## Arquitetura
Apliquei uma Arquitetura Exagonal para permitir a evolução do dominio independentemente das bordas do projeto, baseando no conceito de
portas são as interfaces e adaptadores são a implementações.  
Efetuei tratamento de erro usando exceptions e adicionei uma classe básica de log para lançar outputs no stdout.  
Os testes unitários usei abordagem TDD.    
E o design da arquitetura usei idéias propostas pelo DDD.  


## Comentários
Fazer esse desafio foi uma experiência enriquecedora e de muito aprendizado, pois pensei na solução pensando nos requisitos não funcionais propostos:
- design da solução

- legibilidade

- facilidade de evolução e manutenção da aplicação

- testes automatizados / uso de boas práticas de agilidade

- operacionalidade

- arquitetura da aplicação

## Execução
Para executar a aplicação acessar o diretório Trains.Console execute dotnet run e o input proposto.  
Ex: dotnet run "AB5, BC4, CD8, DC8, DE6, AD5, CE2, EB3, AE7"
