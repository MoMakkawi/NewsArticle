//using GenericServices;

//using MediatR;

//using NewsArticles.API.Domain.Entities;

//namespace NewsArticles.API.Application.Features.Comments.Commands;
//internal sealed record UpdateCommentCommand(Guid Id, string Content) : IRequest<UpdateCommentResponse>;
//internal sealed record UpdateCommentResponse(string Message);
//internal sealed class UpdateCommentHandler(ICrudServicesAsync servicesAsync)
//    : IRequestHandler<UpdateCommentCommand, UpdateCommentResponse>
//{
//    public async Task<UpdateCommentResponse> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
//    {
//        var comment = await servicesAsync.ReadSingleAsync<Comment>(request.Id)
//            ?? throw new ArgumentException("There no Comment with the input Id.");

//        comment.Content = request.Content;

//        await servicesAsync.UpdateAndSaveAsync(comment);

//        return new UpdateCommentResponse("Comment added to the news article repository");
//    }
//}
