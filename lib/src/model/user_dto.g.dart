// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'user_dto.dart';

// **************************************************************************
// BuiltValueGenerator
// **************************************************************************

class _$UserDto extends UserDto {
  @override
  final JsonObject? email;
  @override
  final JsonObject? password;

  factory _$UserDto([void Function(UserDtoBuilder)? updates]) =>
      (UserDtoBuilder()..update(updates))._build();

  _$UserDto._({this.email, this.password}) : super._();
  @override
  UserDto rebuild(void Function(UserDtoBuilder) updates) =>
      (toBuilder()..update(updates)).build();

  @override
  UserDtoBuilder toBuilder() => UserDtoBuilder()..replace(this);

  @override
  bool operator ==(Object other) {
    if (identical(other, this)) return true;
    return other is UserDto &&
        email == other.email &&
        password == other.password;
  }

  @override
  int get hashCode {
    var _$hash = 0;
    _$hash = $jc(_$hash, email.hashCode);
    _$hash = $jc(_$hash, password.hashCode);
    _$hash = $jf(_$hash);
    return _$hash;
  }

  @override
  String toString() {
    return (newBuiltValueToStringHelper(r'UserDto')
          ..add('email', email)
          ..add('password', password))
        .toString();
  }
}

class UserDtoBuilder implements Builder<UserDto, UserDtoBuilder> {
  _$UserDto? _$v;

  JsonObject? _email;
  JsonObject? get email => _$this._email;
  set email(JsonObject? email) => _$this._email = email;

  JsonObject? _password;
  JsonObject? get password => _$this._password;
  set password(JsonObject? password) => _$this._password = password;

  UserDtoBuilder() {
    UserDto._defaults(this);
  }

  UserDtoBuilder get _$this {
    final $v = _$v;
    if ($v != null) {
      _email = $v.email;
      _password = $v.password;
      _$v = null;
    }
    return this;
  }

  @override
  void replace(UserDto other) {
    _$v = other as _$UserDto;
  }

  @override
  void update(void Function(UserDtoBuilder)? updates) {
    if (updates != null) updates(this);
  }

  @override
  UserDto build() => _build();

  _$UserDto _build() {
    final _$result = _$v ??
        _$UserDto._(
          email: email,
          password: password,
        );
    replace(_$result);
    return _$result;
  }
}

// ignore_for_file: deprecated_member_use_from_same_package,type=lint
