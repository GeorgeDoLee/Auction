namespace Auction.Domain.Exceptions;

public class NotFoundException(string resourceType, int resourceIdentifier) 
    : Exception($"{resourceType} with id: {resourceIdentifier} couldn't be found.")
{
}
