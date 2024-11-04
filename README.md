# InScreening

Bem-vindo ao InScreening! 🚀
<br><br>

## RM dos Participantes

- **João Vito** - **RM86293**
- **Marco Antonio** - **RM550128**
- **Vinícius Andrade** - **RM99343**
- **Leonardo Bruno** - **RM552408**
<br><br>

## Por que a Escolha da API de Microservices?

Para o projeto **InScreening**, optamos pela arquitetura de microservices devido à sua capacidade superior de atender às necessidades de escalabilidade, flexibilidade e manutenção, especialmente com a visão de crescimento futuro do sistema. 

### 1. **Escalabilidade Independente**

À medida que o InScreening cresce e a demanda aumenta, a capacidade de escalar partes específicas da aplicação de forma independente se torna crucial. A arquitetura de microservices permite que cada serviço seja escalado individualmente.

### 2. **Desenvolvimento Ágil e Iterativo**

Com microservices, diferentes equipes podem trabalhar simultaneamente em diferentes serviços. Isso não apenas acelera o processo de desenvolvimento, mas também permite a implementação de novas funcionalidades e melhorias de forma mais ágil e menos intrusiva. 
<br><br>
## Design Pattern

Nesta aplicação, utilizamos o padrão **Injeção de Dependência (Dependency Injection - DI)** para gerenciar e configurar as dependências dos serviços. A Injeção de Dependência promove um design de software mais modular e testável ao desacoplar a criação das dependências do seu uso. Isso é alcançado fornecendo as dependências de fora para dentro, assim como mostra na imagem 
<br><br>
![image](https://github.com/user-attachments/assets/ffdbcb83-7b83-4bf5-8544-eae8555f0586)

## Instruções para rodar a API

Ao rodar o projeto ira cair nesta tela. Se atente aos Remarks e siga eles para ter um fluxo de entendimento melhor
<br><br>
![image](https://github.com/user-attachments/assets/b0e74465-3c54-45c3-9fd6-5636a73dca60)

<br><br>
## Fique atento nos metodos Post
Em metodos Post **fique atento** aos Sample request, há campos que são enums para não aceitar outros tipo de informações assim como sexo no cadastro de paciente e na adição de uma nova triagem.
![image](https://github.com/user-attachments/assets/b8d2feab-3597-40f4-a499-70e325291399)

<br><br>

## Para testar nossa nova implementação você precisa rodar a outra API que criamos. Segue link para clonar e rodar:
https://github.com/MarcoAraujo02/InScreening-IA.git 
<br>

Estamos usando este endpoint "/Get_exames" para em nossa API de .Net retornar todos os exames que foram feitos
![image](https://github.com/user-attachments/assets/ecf2162b-2456-444f-b856-e851b4dd4431)

<br><br>
Se colocarmos no Postman vemos todos que foram cadastrados

![image](https://github.com/user-attachments/assets/c879948f-ba2e-4b76-8eb0-052cdb40a34d)
<br>

## Realizando conexão


Com este codigo usando o HttpClient efetuamos a conexão entre as APIs para pegar o endpoint que precisamos

 ![image](https://github.com/user-attachments/assets/88a54298-112c-485d-be3a-185930c3127b)
<br><br>
 Apos isso chamamos o metodo criado na controller e documentamos
 
 ![image](https://github.com/user-attachments/assets/92da8d5f-acfe-4b8f-8f0a-03970cb56b90)

 ## Resultado no Swagger

E quando testarmos ira retornar igual no swagger. (Caso a sua API de python esteja desligada ira retornar o erro 500)
 ![image](https://github.com/user-attachments/assets/5750a964-cf56-4048-873c-3ba897c0fcc0)


## Pratica Clean code e SOLID

Clean Code e SOLID
Este projeto aplica práticas de Clean Code e os princípios SOLID para manter o código limpo, modular e fácil de manter.

Clean Code: Utilizamos nomes significativos, funções pequenas e código autoexplicativo. Removemos código morto e mantemos uma formatação consistente.
SOLID:
<br>
--SRP (Single Responsibility): Cada classe possui uma única responsabilidade.
<br>
--OCP (Open/Closed): Classes estão abertas para extensão, mas fechadas para modificação.
<br>
--LSP (Liskov Substitution): Classes derivadas podem substituir a base sem alterar o comportamento.
<br>
--ISP (Interface Segregation): Interfaces pequenas e específicas evitam implementações desnecessárias.
<br>
--DIP (Dependency Inversion): Dependências são injetadas, facilitando testes e modularidade.
<br>
Essas práticas aumentam a clareza do código e reduzem o acoplamento, tornando o sistema mais robusto e fácil de evoluir.





