#!/bin/bash

# Nome do projeto (ajuste se necessário)
PROJECT_NAME="criptografia_csharp"
PROJECT_DIR="./criptografia_csharp"
PUBLISH_DIR="./publish"

echo "Iniciando processo de release para $PROJECT_NAME..."

# Limpar diretório de publish anterior
if [ -d "$PUBLISH_DIR" ]; then
    echo "Limpando diretório de publish antigo..."
    rm -rf "$PUBLISH_DIR"
fi

# Restaurar dependências
echo "Restaurando dependências..."
dotnet restore "$PROJECT_DIR/$PROJECT_NAME.csproj"

# Publicar o projeto
# -c Release: Configuração de produção
# -o $PUBLISH_DIR: Diretório de saída
# --self-contained false: Usa o runtime do sistema (reduz tamanho)
# Se quiser self-contained, mude para true e adicione -r linux-x64
echo "Publicando projeto em modo Release..."
dotnet publish "$PROJECT_DIR/$PROJECT_NAME.csproj" -c Release -o "$PUBLISH_DIR" --self-contained false

if [ $? -eq 0 ]; then
    echo "----------------------------------------"
    echo "Sucesso! O release está pronto em: $PUBLISH_DIR"
    echo "Para executar: ./publish/$PROJECT_NAME"
    echo "----------------------------------------"
else
    echo "Erro durante o processo de publicação."
    exit 1
fi
