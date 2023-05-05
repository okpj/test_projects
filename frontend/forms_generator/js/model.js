class Form {
  name;
  postmessag;
  items;

  constructor(object) {
    Object.assign(this, object);
    this.items = this.items.map((x) => new Item(x));
  }
}

class Item {
  type;
  name;
  placeholder;
  required;
  label;
  class;
  disabled;
  value;
  checked;
  options;
  items;
  validationRules;

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
  value;
  text;
  selected;

  constructor(object) {
    Object.assign(this, object);
  }
}

class RadioItem {
  value;
  label;
  checked;

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
