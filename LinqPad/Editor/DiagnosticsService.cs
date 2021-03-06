﻿using LinqPad.Editor;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqPad.Editor
{
    public sealed class DiagnosticsService
    {
        private readonly LinqPadEditorHost host;

        public DiagnosticsService(LinqPadEditorHost host)
        {
            this.host = host;
        }

        public async Task<List<Diagnostic>> GetDiagnostics(DocumentId documentId)
        {
            var model = await this.host.GetDocument(documentId).GetSemanticModelAsync().ConfigureAwait(false);
            var diagnostics = model.GetDiagnostics();
            return diagnostics.ToList();
        }
    }
}
