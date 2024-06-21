//P1
let salaries = {
    John: 100,
    Ann: 160,
    Pete: 130
}

var sum = 0;
for (let key in salaries) {
    sum += salaries[key];
}

console.log(sum);

//P2
function multiplyNumeric(obj) {
    for (let key in obj) {
        if (typeof obj[key] == 'number') {
            obj[key] *= 2;
        }
    }
}

// before the call
let menu = {
    width: 200,
    height: 300,
    title: "My menu"
};
multiplyNumeric(menu);
// after the call
console.log(menu);

//P3
function checkEmailId(str) {
    let reg = /@.+\./;
    return reg.test(str);
}

console.log(checkEmailId("abc@gmail.com"));
console.log(checkEmailId("abc@gmailcom"));

//P4
function truncate(str, maxlength) {
    if (str.length > maxlength) {
        return str.slice(0, maxlength - 1) + '...';
    }
    return str;
}

console.log(truncate("What I'd like to tell on this topic is:", 20));
console.log(truncate("Hi everyone!", 20));

//P5
let arr = ["James", "Brennie"];
console.log(arr);
arr.push("Robert");
console.log(arr);
var i = arr.length / 2;
arr.splice(i, 1, "Calvin");
console.log(arr);
console.log(arr.shift());
console.log(arr);
arr.unshift("Rose", "Regal");
console.log(arr);