function createAssemblyLine() {
    const assemblyLine = {
        hasClima(mycar) {
            mycar['temp'] = 21;
            mycar['tempSettings'] = 21;
            mycar['adjustTemp'] = function () {
                if (mycar['temp'] < mycar['tempSettings']) {
                    mycar['temp'] += 1;
                } else if (mycar['temp'] > mycar['tempSettings']) {
                    mycar['temp'] -= 1;
                }
            }
        },
        hasAudio(mycar) {
            mycar['currentTrack'] = {};
            mycar['nowPlaying'] = function () {
                if (mycar['currentTrack'] !== null) {
                    console.log(`Now playing '${this.currentTrack.name}' by ${this.currentTrack.artist}`);
                }
            }
        },
        hasParktronic(mycar) {
            mycar['checkDistance'] = function (distance) {
                if (distance < 0.1) {
                    console.log("Beep! Beep! Beep!");
                } else if (distance < 0.25) {
                    console.log("Beep! Beep!");
                } else if (distance < 0.5) {
                    console.log("Beep!");
                }
            }
        }
    }
    return assemblyLine;
}

const assemblyLine = createAssemblyLine();

const myCar = {
    make: 'Toyota',
    model: 'Avensis'
};

assemblyLine.hasClima(myCar);
console.log(myCar.temp);
myCar.tempSettings = 18;
myCar.adjustTemp();
console.log(myCar.temp);

assemblyLine.hasAudio(myCar);
myCar.currentTrack = {
    name: 'Never Gonna Give You Up',
    artist: 'Rick Astley'
};
myCar.nowPlaying();

assemblyLine.hasParktronic(myCar);
myCar.checkDistance(0.4);
myCar.checkDistance(0.2);

console.log(myCar);