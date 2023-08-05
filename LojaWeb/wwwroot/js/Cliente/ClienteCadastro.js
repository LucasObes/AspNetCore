document.getElementById("Cep").addEventListener("focusout", () => buscarDados());

function buscarDados() {
    let cep = document.getElementById("Cep").value.trim().replace("-", "");

    if (cep.length != 8) {
        return;
    }

    // comunicação com a fonte que eu informar para preencher os campos que preciso
    fetch(`https://viacep.com.br/ws/${cep}/json/`)
        .then((response) => response.json())
        .then((json) => {
            document.getElementById("Cidade").value = json.localidade;
            document.getElementById("Logradouro").value = json.logradouro;
            document.getElementById("Bairro").value = json.bairro;
            document.getElementById("Estado").value = json.uf;
            document.getElementById("Numero").focus();
        });
}