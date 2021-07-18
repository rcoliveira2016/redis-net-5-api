using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace redis_net_5_api.Controllers
{
    
    public class Logo
    {
        public string Tamanho { get; set; }
        public string Imagem { get; set; }
        public string Tipo { get; set; }
    }

    public class Traducoes
    {
        public string ACESSO_CLIENTE { get; set; }
        public string ACESSO_REPRESENTANTE { get; set; }
        public string ALTERARSENHA { get; set; }
        public string APELIDO { get; set; }
        public string BOTAOACESSAR { get; set; }
        public string BOTAOCANCELAR { get; set; }
        public string BOTAOENVIAR { get; set; }
        public string BOTAOLOGIN { get; set; }
        public string CONFIRMASENHA { get; set; }
        public string EMAIL_CHAVE_ACESSO_ASSUNTO { get; set; }
        public string EMAIL_CHAVE_ACESSO_TEXTO_ADM_SISTEMA { get; set; }
        public string EMAIL_CHAVE_ACESSO_TEXTO_SUA_SENHA { get; set; }
        public string EMAIL_CHAVE_ACESSO_USUARIO { get; set; }
        public string EMAILENDERECO { get; set; }
        public string ESQUECEUSENHA { get; set; }
        public string MSG_CLIENTE_INFORMADO_INVALIDO { get; set; }
        public string MSG_CONFIRMSENHA_NAO_CONFERE { get; set; }
        public string MSG_DIGITAR_USUSENHA { get; set; }
        public string MSG_EMAILINVALIDO_USUARIO { get; set; }
        public string MSG_FUNCIONALIDADE_NAO_DISPONIVEL_USUARIO_AD { get; set; }
        public string MSG_INFORMCLIENTE { get; set; }
        public string MSG_INFORME_EMAILVALIDO { get; set; }
        public string MSG_INFORME_USUVALIDO { get; set; }
        public string MSG_NECESSARIO_CONFIRMSENHA { get; set; }
        public string MSG_NECESSARIO_INFORMAR_USUEMAIL { get; set; }
        public string MSG_NECESSARIO_NOVASENHA { get; set; }
        public string MSG_NECESSARIO_SENHAATUAL { get; set; }
        public string MSG_SEM_ACESSO_APLICACAO { get; set; }
        public string MSG_SENHA_DEVE_RESPEITAR_MASCARA { get; set; }
        public string MSG_SENHA_INVALIDA { get; set; }
        public string MSG_SENHA_JA_FOI_UTILIZADA { get; set; }
        public string MSG_SENHANOVA_IGUAL_ANTIGA { get; set; }
        public string MSG_USUARIO_BLOQUEADO { get; set; }
        public string MSG_USUARIO_BLOQUEADO_ULTRAPASSOU_TENTATIVAS { get; set; }
        public string MSG_USUARIO_SEM_PERMISSAO_NESTE_HORARIO { get; set; }
        public string MSG_USUARIO_SENHA_INVALIDOS { get; set; }
        public string MSG_USUARIO_SERA_BLOQUEADO_PROX_TENTATIVA { get; set; }
        public string NOVASENHA { get; set; }
        public string PRIMEIROACESSOINI { get; set; }
        public string SENHA { get; set; }
        public string SENHAATUAL { get; set; }
        public string TEXTOESCOLHACLI { get; set; }
        public string TEXTOESQUECISENHA { get; set; }
        public string TEXTOESQUECISENHACOMPL { get; set; }
        public string TEXTOPRIMEIROACESSO { get; set; }
        public string TEXTOTROCASENHAPADRAO { get; set; }
        public string USUARIO { get; set; }
        public string CNPJ { get; set; }
        public string CONFIRMACAO { get; set; }
    }

    public class Imagen
    {
        public string AbaId { get; set; }
        public string ImagemUrl { get; set; }
    }

    public class ImagensLoad
    {
        public int TempoMinimoExibicao { get; set; }
        public List<Imagen> Imagens { get; set; }
    }

    public class ConfiguracaoInicial
    {
        public string NomeApp { get; set; }
        public string NomeAppSimplificado { get; set; }
        public string CorFundo { get; set; }
        public string CorTema { get; set; }
        public string CorTemaContraste { get; set; }
        public List<Logo> Logos { get; set; }
        public Traducoes Traducoes { get; set; }
        public string ImagemFundoLogin { get; set; }
        public string ImagemLogoLogin { get; set; }
        public ImagensLoad ImagensLoad { get; set; }
    }


}
