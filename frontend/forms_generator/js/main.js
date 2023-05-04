const reader = new FileReader();
const errorLableId = "file-input-error";
const formContainerClass = "form-container";

function openFormFileAndCreateForm(input) {
  clearError();

  let file = input.files[0];
  reader.readAsText(file);

  reader.onload = () => {
    var jsonString = reader.result;
    let json = jsonParse(jsonString);
    if (json) {
      var form = new Form(json.form);
      let formElement = form.toHTMLElement();
      // formElement.addEventListener("submit", (e) => console.log(e));
      formElement.action = "javascript:;";
      formElement.onsubmit = (formData) => submit(formData);
      const container = document.getElementsByClassName(formContainerClass)[0];
      container.appendChild(formElement);
    }
  };

  reader.onerror = () => {
    console.error(reader.error);
  };
}

function jsonParse(jsonString) {
  try {
    let json = JSON.parse(reader.result);
    return json;
  } catch (ex) {
    console.error(ex);
    setError("Невалидный json");
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

function submit(form) {
  console.log(form);
}
