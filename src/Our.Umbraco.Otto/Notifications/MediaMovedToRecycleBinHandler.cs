// Copyright 2024 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using Our.Umbraco.Otto.Core;
using Our.Umbraco.Otto.Core.Selectors;
using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Notifications;

namespace Our.Umbraco.Otto.Notifications;

public class MediaMovedToRecycleBinHandler : INotificationHandler<MediaMovedToRecycleBinNotification>
{
    private readonly IOrganizerSelector<IMedia> _selector;

    public MediaMovedToRecycleBinHandler(IOrganizerSelector<IMedia> selector) => _selector = selector;

    public void Handle(MediaMovedToRecycleBinNotification notification) =>
        _selector.Organize(notification.MoveInfoCollection.Select(e => e.Entity).ToArray(), OrganizerMode.Cleanup);
}