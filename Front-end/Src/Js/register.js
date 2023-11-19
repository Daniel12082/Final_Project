(function () {
	'use strict'

	// Fetch all the forms we want to apply custom Bootstrap validation styles to
	var forms = document.querySelectorAll('.needs-validation')

	// Loop over them and prevent submission
	Array.prototype.slice.call(forms)
		.forEach(function (form) {
			form.addEventListener('submit', function (event) {
				if (!form.checkValidity()) {
					event.preventDefault()
					event.stopPropagation()
				}

				form.classList.add('was-validated')
			}, false)
		})
})()
document.addEventListener("DOMContentLoaded", function() {
    document.querySelector("form").addEventListener("submit", function(event) {
        event.preventDefault();
        var email = document.getElementById("email").value;
        var password = document.getElementById("password").value;
        // Crear un objeto con los datos del formulario
        var data = {
            email: email,
            password: password
        };
        const endpointUrl = "http://localhost:5019/user/register";
        // Realizar la solicitud HTTP con los datos del formulario
        fetch(endpointUrl, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(data),
            })
            .then(response => {
                if (response.status === 200) {
                    window.location.href = "/index.html"; // Redirige si el registro es exitoso
                } else if (response.status === 400) {
                    throw new Error('El usuario ya está registrado');
                } else {
                    throw new Error('Error al registrar usuario');
                }
            })
            .catch(error => {
                // Manejar errores y mostrar mensaje de error
                alert(error.message);
            });
    });
});