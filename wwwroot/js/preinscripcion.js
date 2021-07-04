// AGREGAR OPCION PARA AGREGAR UN TELEFONO ALTERNATIVO


const checkboxFamiliares = document.getElementById('checkbox-familiares')

const divCheckboxPadre = document.getElementById('checkbox-padre')
const divContentPadre = document.getElementById('div-padre')

const divCheckboxMadre = document.getElementById('checkbox-madre')
const divContentMadre = document.getElementById('div-madre')

const divCheckboxTutor = document.getElementById('checkbox-tutor')
const divContentTutor = document.getElementById('div-tutor')



const divSelectCategoria = document.getElementById('div-categoria')
const selectCategoria = document.getElementById('categoria')

const divSelectEjercito = document.getElementById('div-ejercito')
const divSelectArmada = document.getElementById('div-armada')
const divSelectFuerza_aerea = document.getElementById('div-fuerza-aerea')

// const div_select_gendarmeria = document.getElementById('div_select_gendarmeria')
// const div_select_prefecutra_naval = document.getElementById('div_select_prefecutra_naval')
// const div_select_policia_federal = document.getElementById('div_select_policia_federal')
// const div_select_policia_federal_seguridad_aeropuertaria = document.getElementById('div_select_policia_federal_seguridad_aeropuertaria')
// const div_select_policia_tucuman = document.getElementById('div_select_policia_tucuman')

divSelectEjercito.remove()
divSelectArmada.remove()
divSelectFuerza_aerea.remove()

divSelectCategoria.insertAdjacentElement("afterend", divSelectEjercito)
// Agregar o quitar optionces escuelas
selectCategoria.addEventListener('change', () => {
    if (selectCategoria.value == "Ejercito") {
        divSelectCategoria.insertAdjacentElement("afterend", divSelectEjercito)
    } else {
        divSelectEjercito.remove()
    }

    if (selectCategoria.value == "Armada") {
        divSelectCategoria.insertAdjacentElement("afterend", divSelectArmada)
    } else {
        divSelectArmada.remove()
    }

    if (selectCategoria.value == "Fuerza Aerea") {
        divSelectCategoria.insertAdjacentElement("afterend", divSelectFuerza_aerea)
    } else {
        divSelectFuerza_aerea.remove()
    }


})
// divContentPadre.remove()

// checkboxFamiliares.insertAdjacentElement("afterend", divContentPadre)


// const selectCategoria = document.getElementById('categoria')

// selectCategoria.disabled = true


// if (document.getElementById('checkbox-padre').checked) {
//     alert("checked")
// }else{
//     alert("not checked")
// }

divContentPadre.remove()
divContentMadre.remove()
divContentTutor.remove()


divCheckboxPadre.addEventListener('click', () => {
    if (divCheckboxPadre.children[0].checked == true) {
        checkboxFamiliares.insertAdjacentElement("afterend", divContentPadre)
    } else {
        divContentPadre.remove()
    }
})

divCheckboxMadre.addEventListener('click', () => {
    if (divCheckboxMadre.children[0].checked == true) {
        checkboxFamiliares.insertAdjacentElement("afterend", divContentMadre)
    } else {
        divContentMadre.remove()
    }
})

divCheckboxTutor.addEventListener('click', () => {
    if (divCheckboxTutor.children[0].checked == true) {
        checkboxFamiliares.insertAdjacentElement("afterend", divContentTutor)
    } else {
        divContentTutor.remove()
    }
})

// checkbox_padre.addEventListener('click', () => {
//     div_padre.style.display = 'contents'
// })

// checkbox_padre.addEventListener('click', () => {
//     div_padre.style.display = 'contents'
// })


// cpadre.addEventListener('click', () => {
//     cpadre.style.display = 'contents';
// })

// cpadre.addEventListener('')


// const inputs = document.querySelectorAll('input')




document.addEventListener("DOMContentLoaded", () => {
    const inputFechaNacimiento = document.getElementById('fecha-nacimiento')

    const fecha = new Date()
    const DIA_MIN = 01
    const MES_MIN = 01
    const ANO_MIN = fecha.getFullYear() - 85

    const DIA_MAX = fecha.getDate()
    const MES_MAX = fecha.getMonth() + 1
    const ANO_MAX = fecha.getFullYear() - 16

    const fecha_actual = fecha.getFullYear() + '-' + (fecha.getMonth() + 1) + '-' + fecha.getDate()
    const FECHA_MIN_PERMITIDA = ANO_MIN + '-' + MES_MIN + '-' + DIA_MIN
    const FECHA_MAX_PERMITIDA = ANO_MAX + '-' + MES_MAX + '-' + DIA_MAX
    inputFechaNacimiento.min = FECHA_MIN_PERMITIDA
    inputFechaNacimiento.max = FECHA_MAX_PERMITIDA
})



// const btn_submit = document.getElementById('')


function ObtenerInputs() {
    const inputNombre = document.getElementById('nombre')
    const inputApellido = document.getElementById('apellido')
    const inputDni = document.getElementById('dni')
    const inputFechaNacimiento = document.getElementById('fecha-nacimiento')
    const inputCodigoArea = document.getElementById('codigo-area')
    const inputNumeroTel = document.getElementById('numero-tel')
    const inputEmail = document.getElementById('email')
    const inputLocalidad = document.getElementById('localidad')

    const selectProvincia = document.getElementById('provincia')
    const selectDepartamento = document.getElementById('departamento')
    const selectEstablecimiento = document.getElementById('establecimiento')

    const selectGrupo = document.getElementById('grupo')

    const selectEjercitoEscuela = document.getElementById('ejercito-escuela')
    const selectArmadaEscuela = document.getElementById('armada-escuela')
    const selectFuerzaAereaEscuela = document.getElementById('fuerza-aerea-escuela')

    const inputRadioTurno = document.getElementById('');
}



// queda validar los datos de la escuela y los tutores
//Realizar modifiaciones en el formulario, revisar notion

function ValidarDatos() {
    btn_submit.addEventListener('onsubmit', () => {
        let todo_correcto = true

        const diaNacimiento = inputFechaNacimiento.value[0] + inputFechaNacimiento.value[1] + inputFechaNacimiento.value[2] + inputFechaNacimiento.value[3]
        const mesNacimiento = inputFechaNacimiento.value[5] + inputFechaNacimiento.value[6]
        const anoNacimiento = inputFechaNacimiento.value[8] + inputFechaNacimiento.value[9]

        if (inputNombre.value.length > 80 || inputNombre.value == '' || inputApellido.value.length > 80 || inputApellido.value == '') {
            todo_correcto = false
        }

        if (isNaN(parseInt(inputDni.value))) {
            todo_correcto = false
        }

        if ((parseInt(anoNacimiento) < (fecha.getFullYear() - 85)) && (parseInt(anoNacimiento) > (fecha.getFullYear() - 16))) {
            todo_correcto = false
        }

        if ((inputCodigoArea.value.length > 6 || isNaN(parseInt(inputCodigoArea.value))) || (inputNumeroTel.value.length > 10 || isNaN(parseInt(inputNumeroTel.value)))) {
            todo_correcto = false
        }

        if ((inputEmail.value == '' || (inputEmail.value.length < 6 && inputEmail.value.length > 40))) {
            todo_correcto = false
        } else {
            if ((inputEmail.value.split('@'))[1] != 'gmail.com') {
                alert('el mail debe ser con dominio @gmail.com')
                todo_correcto = false
            }
        }

        if (selectProvincia.value == '' || selectDepartamento.value == '' || selectEstablecimiento.value == '' || selectGrupo.value == '') {
            todo_correcto = false
        } else {
            if (selectEjercitoEscuela.value == '') {
                todo_correcto = false
            } else if (selectArmadaEscuela.value == '') {
                todo_correcto = false
            } else if (selectFuerzaAereaEscuela.value == '') {
                todo_correcto = false
            }
        }
    })

    return true;
}

document.addEventListener('submit', () => {
    if (ValiarDatos()) {
        //enviar fomulario
    } else {
        //Mostrar mensaje de error
    }
})




//---------------------- PRUEBA -------------------------------------

const inputEmail = document.getElementById('email')
const inputFechaNacimiento = document.getElementById('fecha-nacimiento')
const btnReturn = document.getElementById('return-button')
const inputNumeroTel = document.getElementById('numero-tel')

var string_inputFechaNacimiento = new Array(3)
string_inputFechaNacimiento = (inputFechaNacimiento.value).split('-')

const inputs_radios = document.querySelectorAll('input[name=turno]')

const fecha_fijada = new Date(1998, 07, 13)

// verificar checked de html

btnReturn.addEventListener('click', () => {
    var day = fecha_fijada.getFullYear()

    for (let i = 0; i < inputs_radios; i++) {
        const element = inputs_radios[i];
        if (element.checked) {
            console.log('input')
        }
    }
})
