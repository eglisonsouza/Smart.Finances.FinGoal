using MediatR;
using Smart.Finances.FinGoal.Application.Commands.FinancialGoalCommands.UpdateStatus.Commands;
using Smart.Finances.FinGoal.Application.Commands.FinancialGoalCommands.ViewModels;
using Smart.Finances.FinGoal.Core.Exceptions;
using Smart.Finances.FinGoal.Core.Models.Entities;
using Smart.Finances.FinGoal.Core.Models.Enuns;
using Smart.Finances.FinGoal.Core.Repositories;

namespace Smart.Finances.FinGoal.Application.Commands.FinancialGoalCommands.UpdateStatus
{
    public class UpdateStatusFinancialGoalHandler(IFinancialGoalRepository repository) :
        IRequestHandler<CancellFinancialGoalCommand, FinancialGoalViewModels>,
        IRequestHandler<CompletedFinancialGoalCommand, FinancialGoalViewModels>,
        IRequestHandler<HoldFinancialGoalCommand, FinancialGoalViewModels>,
        IRequestHandler<BackFinancialGoalCommand, FinancialGoalViewModels>
    {

        private readonly IFinancialGoalRepository _repository = repository;

        public async Task<FinancialGoalViewModels> Handle(CancellFinancialGoalCommand request, CancellationToken cancellationToken)
        {
            var entity = await GetEntity(request.Id);
            entity!.Cancell();
            return await ExecuteAsync(entity);
        }

        public async Task<FinancialGoalViewModels> Handle(CompletedFinancialGoalCommand request, CancellationToken cancellationToken)
        {
            var entity = await GetEntity(request.Id);
            if (entity!.Status.Equals(FinancialGoalStatus.Cancelled))
                throw new StatusCannotBeCanceledException();
            entity!.Completed();
            return await ExecuteAsync(entity);
        }

        public async Task<FinancialGoalViewModels> Handle(HoldFinancialGoalCommand request, CancellationToken cancellationToken)
        {
            var entity = await GetEntity(request.Id);
            if (entity!.Status.Equals(FinancialGoalStatus.Cancelled))
                throw new StatusCannotBeCanceledException();
            entity!.Hold();
            return await ExecuteAsync(entity);
        }

        public async Task<FinancialGoalViewModels> Handle(BackFinancialGoalCommand request, CancellationToken cancellationToken)
        {
            var entity = await GetEntity(request.Id);
            if (entity!.Status.Equals(FinancialGoalStatus.Cancelled))
                throw new StatusCannotBeCanceledException();
            entity!.Back();
            return await ExecuteAsync(entity);
        }

        private async Task<FinancialGoalViewModels> ExecuteAsync(FinancialGoal entity)
        {
            _repository.Update(entity);
            return FinancialGoalViewModels.FromEntity(entity);
        }

        private Task<FinancialGoal?> GetEntity(Guid id)
        {
            return _repository.GetById(id) ?? throw new EntityNotFoundException();
        }
    }
}
