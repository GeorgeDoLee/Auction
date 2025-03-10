﻿namespace Auction.Domain.Exceptions;

public class NotFoundException(string resourceType, string resourceIdentifier) 
    : Exception($"{resourceType} with identifier: {resourceIdentifier} couldn't be found.")
{
}
