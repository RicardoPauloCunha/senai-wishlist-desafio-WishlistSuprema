## Caminho das requisições (API)  

- ### Usuario  

   - #### Listar Desejos  

    **Metodo** : GET  
    **Caminho** : */api/usuario/desejos*  
    **Retorno** : Lista com um usuario e seus desejos dentro dele  
	**Requisitos** : Estar logado , ter desejos  

  - #### Cadastrar Usuario  

   **Metodo** : POST  
    **Parametros** : Um usuario (Nome, email e senha)  
    **Caminho** : */api/usuario/cadastrar*  
    **Retorno** : Uma mensagem de sucesso se o usuario for cadastrado  
	**Requisitos** : Estar logado  

  - #### Fazer login

   **Metodo** : POST
    **Parametros** : Usuario View Model (Email e senha)
    **Caminho** : */api/usuario/login*
    **Retorno** : Um token de validação se o usuario for logado com sucesso
	**Requisitos** : Não tem  

- ### Desejo  

   - #### Listar Desejos  

    **Metodo** : GET  
    **Caminho** : */api/desejo/listar*  
    **Retorno** : Lista todas  
	**Requisitos** : Estar logado , ter desejos no banco de dados  

  - #### Cadastrar Desejo  

   **Metodo** : POST  
    **Parametros** : Um Desejo (Nome e descrição)  
    **Caminho** : */api/desejo/cadastro*  
    **Retorno** : Uma mensagem de sucesso se o desejo for cadastrado  
	**Requisitos** : Estar logado  
