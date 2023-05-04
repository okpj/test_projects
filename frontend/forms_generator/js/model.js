class Form {
  name = "";
  postmessage = "";
  items = [new Item()];

  constructor(object) {
    Object.assign(this, object);
    this.items = this.items.map((x) => new Item(x));
  }
}

class Item {
  type = "";
  name = "";
  placeholder = "";
  required = false;
  label = "";
  class = "";
  disabled = false;
  value = "";
  checked = false;
  options = [new SelectOption()];
  items = [new RadioItem()];
  validationRules = new ValidationRules();

  constructor(object) {
    Object.assign(this, object);
    if (this.type == ElementType.select) {
      this.options = this.options.map((x) => new SelectOption(x));
    } else if (this.type == ElementType.radio) {
      this.items = this.items.map((x) => new RadioItem(x));
    }
    this.validationRules = new ValidationRules(this.validationRules);
  }
}

class SelectOption {
  value = "";
  text = "";
  selected = false;

  constructor(object) {
    Object.assign(this, object);
  }
}

class RadioItem {
  value = "";
  label = "";
  checked = false;

  constructor(object) {
    Object.assign(this, object);
  }
}

class ValidationRules {
  type;
  constructor(object) {
    Object.assign(this, object);
  }
}

const ElementType = Object.freeze({
  filler: "filler",
  text: "text",
  textarea: "textarea",
  checkbox: "checkbox",
  button: "button",
  select: "select",
  radio: "radio",
});

const ValidationRuleType = Object.freeze({
  text: "text",
  tel: "tel",
  email: "email",
  select: "select",
  radio: "radio",
  checkbox: "checkbox",
});
