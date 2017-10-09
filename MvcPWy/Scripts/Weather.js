'use strict';

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

function _possibleConstructorReturn(self, call) { if (!self) { throw new ReferenceError("this hasn't been initialised - super() hasn't been called"); } return call && (typeof call === "object" || typeof call === "function") ? call : self; }

function _inherits(subClass, superClass) { if (typeof superClass !== "function" && superClass !== null) { throw new TypeError("Super expression must either be null or a function, not " + typeof superClass); } subClass.prototype = Object.create(superClass && superClass.prototype, { constructor: { value: subClass, enumerable: false, writable: true, configurable: true } }); if (superClass) Object.setPrototypeOf ? Object.setPrototypeOf(subClass, superClass) : subClass.__proto__ = superClass; }

//Weather Widget Component
var WEATHER_API_KEY = '190472589c4641aabec55234172509';
var PLACES_API_KEY = 'AIzaSyBE3vjDJHh3nZBpwB6vE1N-k0LsuausSjA';
var PLACES_PHOTOS_API_KEY = 'AIzaSyBE3vjDJHh3nZBpwB6vE1N-k0LsuausSjA';
var proxyurl = "https://cors-anywhere.herokuapp.com/";

var WeatherWidget = function (_React$Component) {
    _inherits(WeatherWidget, _React$Component);

    function WeatherWidget() {
        _classCallCheck(this, WeatherWidget);

        var _this = _possibleConstructorReturn(this, _React$Component.call(this));

        _this.state = {
            location: '',
            country: '',
            temp: null,
            localTime: null,
            condition: '',
            icon: '',
            cloudPercentage: null,
            loading: false,
            imageUrl: 'http://www.micm.com.au/wp-content/uploads/2013/09/Melbourne-CBD-1.jpg'
        };
        return _this;
    }

    WeatherWidget.prototype.componentDidMount = function componentDidMount() {
        this.getPhotoForCity('melbourne');
        this.getWeatherForCity('melbourne');
    };

    WeatherWidget.prototype.onCitySubmit = function onCitySubmit(event) {
        if (event.keyCode == 13) {
            this.getPhotoForCity(event.target.value);
            this.getWeatherForCity(event.target.value);
        }
    };

    WeatherWidget.prototype.getWeatherForCity = function getWeatherForCity(city) {
        var _this2 = this;

        fetch('https://api.apixu.com/v1/current.json?\tkey=' + WEATHER_API_KEY + '&q=' + city).then(function (response) {
            if (response.status !== 200) {
                console.log('Error fetching data. Respons:' + response.status);
                return;
            }
            response.json().then(function (data) {
                _this2.setState({
                    location: data.location.name,
                    country: data.location.country,
                    temp: data.current.temp_c,
                    localTime: data.location.localtime,
                    condition: data.current.condition.text,
                    icon: data.current.condition.icon,
                    cloudPercentage: data.current.cloud
                });
            });
        }).catch(function (err) {
            console.log('Fetch Error :-S', err);
        });
    };

    WeatherWidget.prototype.getPhotoForCity = function getPhotoForCity(city) {
        var _this3 = this;

        this.setState({ loading: true });
        var url = proxyurl + 'https://maps.googleapis.com/maps/api/place/textsearch/json?query=' + city + '&key=' + PLACES_API_KEY;
        fetch(url).then(function (response) {
            if (response.status !== 200) {
                console.log('Error fetching data. Response:' + response.status);
                return;
            }
            response.json().then(function (data) {
                var photoRef = data.results[0].photos[0].photo_reference;
                var url = proxyurl + 'https://maps.googleapis.com/maps/api/place/photo?maxheight=300&photoreference=' + photoRef + '&key=' + PLACES_PHOTOS_API_KEY;
                fetch(url).then(function (response) {
                    if (response.status !== 200) {
                        console.log('Error fetching data from places API. Response:' + response.status);
                        return;
                    }
                    response.blob().then(function (blob) {
                        var objectURL = URL.createObjectURL(blob);
                        _this3.setState({ imageUrl: objectURL, loading: false });
                    });
                }).catch(function (err) {
                    if (err) {
                        console.log('Fetch Error Photo', err.message);
                    }
                });
            });
        }).catch(function (err) {
            if (err) {
                console.log('Fetch Error Places', err.message);
            }
        });
    };

    WeatherWidget.prototype.getPhotoContainer = function getPhotoContainer() {
        var preloader = this.state.loading ? React.createElement(
            'div',
            { className: 'overlay' },
            React.createElement(
                'div',
                { className: 'loader' },
                React.createElement('img', { src: 'https://image.ibb.co/meRVm5/sun_1.png' })
            )
        ) : null;
        return React.createElement(
            'div',
            { className: 'image', style: { backgroundImage: 'url(' + this.state.imageUrl + ')' } },
            preloader
        );
    };

    WeatherWidget.prototype.getInfoContainer = function getInfoContainer() {
        var _state = this.state;
        var condition = _state.condition;
        var temp = _state.temp;
        var location = _state.location;
        var localTime = _state.localTime;

        return React.createElement(
            'div',
            { className: 'info' },
            React.createElement(
                'div',
                { className: 'temp' },
                React.createElement(
                    'span',
                    { className: 'value' },
                    temp,
                    '°'
                ),
                React.createElement(
                    'span',
                    null,
                    condition
                )
            ),
            React.createElement('div', { className: 'hr' }),
            React.createElement(
                'div',
                { className: 'location' },
                React.createElement(
                    'span',
                    { className: 'city' },
                    location
                ),
                React.createElement(
                    'span',
                    null,
                    localTime
                )
            )
        );
    };

    WeatherWidget.prototype.getLocationInput = function getLocationInput() {
        var _this4 = this;

        return React.createElement(
            'div',
            { className: 'inputX' },
            React.createElement('input', {
                className: 'search', type: 'search', placeholder: 'Search location', onKeyPress: function onKeyPress() {
                    return _this4.onCitySubmit(event);
                }
            })
        );
    };

    WeatherWidget.prototype.render = function render() {
        return React.createElement(
            'div',
            null,
            React.createElement(
                'div',
                { className: 'containerX' },
                this.getPhotoContainer(),
                this.getInfoContainer()
            ),
            this.getLocationInput()
        );
    };

    return WeatherWidget;
}(React.Component);

React.render(React.createElement(WeatherWidget, null), document.getElementById('root'));