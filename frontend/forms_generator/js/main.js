const errorLableId = "form-description-error";
const formContainerClass = "form-inner-conrainer";
const formDescriptionId = "form-description";
const formAction = "javascript:;";
const resultId = "result";

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
  clearError();
  let textArea = document.getElementById(formDescriptionId);
  var value = textArea.value;
  var obj = jsonParse(value);
  if (obj) {
    var content = JSON.stringify(obj, undefined, 2);
    textArea.value = content;
  } else {
    setError("Невалидный json");
  }
}

function createForm() {
  clearError();
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
  } else {
    setError("Невалидный json");
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

function setError(error) {
  let errorLable = document.getElementById(errorLableId);
  errorLable.textContent = error;
}

function clearError() {
  let errorLable = document.getElementById(errorLableId);
  errorLable.textContent = "";
}

function handleSubmit(event) {
  event.preventDefault();

  const data = new FormData(event.target);
  const value = Object.fromEntries(data.entries());
  let resultElement = document.getElementById(resultId);
  var content = JSON.stringify(value, undefined, 2);
  resultElement.value = content;
}
