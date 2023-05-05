const reader = new FileReader();

function openFormFile(input) {
  let file = input.files[0];
  reader.readAsText(file);

  reader.onload = () => {
    let textArea = document.getElementById(formDescriptionId);
    textArea.value = reader.result;
  };

  reader.onerror = () => {
    console.error(reader.error);
  };

  input.value = "";
}

function format() {
  clearJsonError();
  let textArea = document.getElementById(formDescriptionId);
  var value = textArea.value;
  var obj = jsonParse(value);
  if (obj) {
    var content = JSON.stringify(obj, undefined, 2);
    textArea.value = content;
  } else {
    setJsonError("Невалидный json");
  }
}

function createForm() {
  clearJsonError();
  let textArea = document.getElementById(formDescriptionId);
  let jsonString = textArea.value;
  let json = jsonParse(jsonString);
  if (json) {
    var form = new Form(json.form);
    let formElement = form.toHTMLElement();
    formElement.action = formAction;
    formElement.onsubmit = (event) => handleSubmit(event);
    const container = document.getElementsByClassName(formContainerClass)[0];
    container.innerHTML = "";
    container.appendChild(formElement);

    let formErrorElement = document.createElement(labelTagName);
    formErrorElement.className = errorLabelClassName;
    formErrorElement.setAttribute("for", formElement.name);
    formErrorElement.id = formErrorLableId;
    container.appendChild(formErrorElement);
  } else {
    setJsonError("Невалидный json");
  }
}

function jsonParse(jsonString) {
  try {
    let json = JSON.parse(jsonString);
    return json;
  } catch (ex) {
    console.error(ex);
    return undefined;
  }
}

function setJsonError(error) {
  let errorLable = document.getElementById(jsonErrorLableId);
  errorLable.textContent = error;
}

function clearJsonError() {
  let errorLable = document.getElementById(jsonErrorLableId);
  errorLable.textContent = "";
}

function setFormError(error) {
  let errorLable = document.getElementById(formErrorLableId);
  errorLable.textContent = error;
}

function clearFormError() {
  let errorLable = document.getElementById(formErrorLableId);
  errorLable.textContent = "";
}

function handleSubmit(event) {
  event.preventDefault();

  const isValid = validateValues(event);
  if (isValid) {
    const formData = new FormData(event.target);
    const formDataProperties = formData.entries();

    const value = Object.fromEntries(formDataProperties);

    let resultElement = document.getElementById(resultId);
    var content = JSON.stringify(value, undefined, 2);
    resultElement.value = content;
  }
}

function validateValues(event) {
  clearFormError();
  let errors = [];
  for (let i = 0; i < event.target.length; i++) {
    const placeholder = event.target.elements[i].placeholder;
    const value = event.target.elements[i].value;
    if (placeholder && placeholder == value) {
      errors.push(`[${event.target.elements[i].name}] - значение не должно быть равно placeholder`);
    }
  }

  if (errors.length > 0) {
    setFormError(errors.join("\n"));
    return false;
  }
  return true;
}
