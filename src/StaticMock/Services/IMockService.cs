﻿using System;

namespace StaticMock.Services
{
    public interface IMockService
    {
        void Returns(object value);
        void Throws(Type exceptionType);
        void Throws<TException>() where TException : Exception, new();
    }
}
