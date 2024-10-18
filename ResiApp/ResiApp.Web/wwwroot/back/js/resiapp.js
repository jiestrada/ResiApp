function sendAjaxRequest(url, method, data, callback) {
    fetch(url, {
        method: method,
        headers: {
            'Content-Type': 'application/json',
            'Accept': 'application/json'
        },
        body: JSON.stringify(data)
    })
        .then(response => {
            if (!response.ok) {
                // Si hay un problema con la respuesta (ej. código 4xx o 5xx), lanzar un error
                return response.json().then(errData => {
                    throw new Error(errData.message || 'Error en la solicitud.');
                });
            }
            return response.json();
        })
        .then(data => callback(null, data)) // Éxito, pasar null como error
        .catch(error => callback(error, null)); // Enviar el error al callback
}

function formValidate  (form) {
    form.validate();
    if (!form.valid()) {
        return false;
    } else {
        return true;
    }
}

function habilitarBtn(btn, enabled, texto) {
    
    if (enabled) {
        btn.disabled = false;
        btn.innerHTML = texto;
    } else {
        btn.disabled = true;
        btn.innerHTML = `
        <span class="spinner-grow spinner-grow-sm" role="status" aria-hidden="true"></span>
        <span>Cargando...</span>
    `;
    }
}